using CMS.Common;
using CMS.IServices.System;
using CMS.Models;
using CMS.Models.ViewModel.SystemViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.UI.Extensions.WebSocketExtension
{
    public class WebsocketHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private static ConcurrentDictionary<string, WebSocket> _userWebSocketDir = new ConcurrentDictionary<string, WebSocket>();
        private string _userID = string.Empty;
        private AESHelper _AESHelper;

        public WebsocketHandlerMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory,
            AESHelper aESHelper
            )
        {
            _next = next;
            _logger = loggerFactory.
                CreateLogger<WebsocketHandlerMiddleware>();
            _AESHelper = aESHelper;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    string token = context.Request.Query["token"];
                    if (string.IsNullOrEmpty(token))
                    {
                        context.Response.StatusCode = 401;

                    }
                    else
                    {
                        JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                        if (jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier) != null)
                        {
                            _userID = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();

                            try
                            {
                                await Handle(webSocket, _userID);
                            }
                            catch (Exception ex)
                            {
                                await context.Response.WriteAsync(ex.Message);
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = 401;
                        }
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            }
            else
            {
                await _next(context);
            }
        }

        private async Task Handle(WebSocket webSocket,string _userID)
        {
            UserWebSocketDirAdd(webSocket,_userID);
            WebSocketReceiveResult result = null;
            do
            {
                var buffer = new ArraySegment<byte>(new byte[2048]);
                result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text && !result.CloseStatus.HasValue)
                {
                    var msgString = Encoding.UTF8.GetString(buffer.Array,0,result.Count);
                    var message = JsonConvert.DeserializeObject<WebSocketMessage>(msgString);
                    SendMessage(message);
                }
            }
            while (!result.CloseStatus.HasValue);
            UserWebSocketDirRemove(_userID);
        }

        public void UserWebSocketDirAdd(WebSocket webSocket, string _userID)
        {
            if (_userWebSocketDir.ContainsKey(_userID))
            {
                _userWebSocketDir[_userID] = webSocket;
            }
            else
            {
                _userWebSocketDir.TryAdd(_userID, webSocket);
            }
        }

        public void UserWebSocketDirRemove(string UserID)
        {
            _userWebSocketDir.Remove(UserID,out WebSocket webSocket);
        }

        public void SendMessage(WebSocketMessage message)
        {
            var receiver = message.Receiver;
            if (!string.IsNullOrEmpty(receiver))
            {
                var msg = Encoding.UTF8.GetBytes(message.Msg);
                if (receiver == _AESHelper.Decrypt(_userID))
                {
                    Parallel.ForEach(_userWebSocketDir, item =>
                    {
                        if (item.Key!=_userID)
                        {
                            item.Value.SendAsync(new ArraySegment<byte>(msg, 0, msg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    });
                }
                else
                {
                    WebSocket websocket = _userWebSocketDir.GetValueOrDefault(receiver);
                    if (websocket!=null)
                    {
                        websocket.SendAsync(new ArraySegment<byte>(msg, 0, msg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
        }
    }
}
