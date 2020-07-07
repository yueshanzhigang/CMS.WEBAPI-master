USE [CMS]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200606065505_InitialCreate', N'5.0.0-preview.4.20220.10')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'0167D372-92AC-4981-A775-0AB0B3324824', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:07:52.1390245' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:07:52.1390524' AS DateTime2), N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'查询用户', N'api/SysUser', 3, 4, 0, N'查询用户操作')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'2178FAA5-EE1A-4183-8F00-12E49DA24F37', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:17:12.4861644' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:17:12.4861829' AS DateTime2), N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'修改角色权限', N'api/SysRole', 4, 6, 0, N'修改角色权限')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'29A2EC2B-6393-426F-BEFD-B24842D6803F', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:00:48.4731772' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:00:48.4731934' AS DateTime2), N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'用户增加', N'api/SysUser', 0, 1, 0, N'增加用户')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'32383D2C-8A91-4A2F-90C6-442A052D2D46', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:16:46.4478965' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:16:46.4479100' AS DateTime2), N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'分页查询角色', N'api/SysRole/GetByPage', 3, 5, 0, N'分页查询角色')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:57:38.3146007' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:57:38.3148975' AS DateTime2), N'', N'菜单管理', N'', 0, 1, 0, N'菜单管理页面')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'451AFA16-3D7B-4C77-9777-69BEB64AEE47', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:15:11.2657259' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:15:11.2657407' AS DateTime2), N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'删除角色', N'api/SysRole', 1, 2, 0, N'删除角色')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'475C708E-0293-4FA2-B847-8966AF724F64', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:20:20.8936919' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:20:20.8937036' AS DateTime2), N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'删除菜单', N'api/SysModule', 1, 2, 0, N'删除菜单')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'5828DE31-0C90-47EC-A00B-687D55C46E9A', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:20:32.3424122' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:20:32.3424252' AS DateTime2), N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'修改菜单', N'api/SysModule', 2, 3, 0, N'修改菜单')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:58:40.0696038' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:58:40.0696250' AS DateTime2), N'', N'用户管理', N'', 0, 3, 0, N'用户管理页面')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'732AB120-7344-4F6B-9DDA-010067EA69F0', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:09:54.7379282' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:09:54.7379405' AS DateTime2), N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'修改密码', N'api/SysUser/UpdatePassword', 2, 6, 0, N'修改登录密码')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'775ABE6A-300C-46C1-B3A4-7DD53A9F47BE', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:09:15.6431796' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:09:15.6431952' AS DateTime2), N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'分页查询用户', N'api/SysUser/GetByPage', 3, 5, 0, N'分页查询用户操作')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'7F17E926-9B1A-4DCB-86C0-329113D53969', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:15:31.2293977' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:15:31.2294205' AS DateTime2), N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'修改角色', N'api/SysRole', 2, 3, 0, N'修改角色')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'964086BC-B6B2-4DAC-BEDC-34B0F445315D', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:01:28.9595977' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:01:28.9596128' AS DateTime2), N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'修改用户', N'api/SysUser', 1, 2, 0, N'修改用户')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'A3E85B22-8C6B-480D-9172-03CD31FB7346', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:07:13.4741911' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:07:13.4742885' AS DateTime2), N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'删除用户', N'api/SysUser', 1, 3, 0, N'删除用户操作')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'A9B46387-5A3D-4460-B3E9-55CC558CDBBC', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:19:41.3606361' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:19:41.3606594' AS DateTime2), N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'增加菜单', N'api/SysModule', 0, 1, 0, N'增加菜单')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'B535DE6E-399D-44EF-B959-D37FE05992B5', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:16:13.0129628' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:16:13.0129826' AS DateTime2), N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'查询角色', N'api/SysRole', 3, 4, 0, N'查询角色')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:58:24.4321427' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:58:24.4321574' AS DateTime2), N'', N'角色管理', N'', 0, 2, 0, N'角色管理页面')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'CC31B967-7A59-4C2B-8C95-AF8412896622', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:22:05.9016582' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:22:05.9016691' AS DateTime2), N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'菜单树', N'api/SysModule/GetForTree', 3, 5, 0, N'获取菜单树')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'D4119FC3-50DB-428F-8985-FA2615334374', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:14:40.1449369' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:14:40.1449541' AS DateTime2), N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'增加角色', N'api/SysRole', 0, 1, 0, N'增加角色')
GO
INSERT [dbo].[SysModule] ([ModuleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [ParentID], [ModuleTitle], [Url], [Method], [Sort], [ModuleState], [Description]) VALUES (N'D7876F81-FBC7-4925-9747-4D04F9C9577B', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:20:47.5382039' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:20:47.5382162' AS DateTime2), N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'查询菜单', N'api/SysModule', 3, 4, 0, N'查询菜单')
GO
INSERT [dbo].[SysRole] ([RoleID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [RoleTitle], [RoleState], [Description]) VALUES (N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:56:42.5066667' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:56:42.5066667' AS DateTime2), N'超级管理员', 1, N'拥有所有权限的超级管理员')
GO
SET IDENTITY_INSERT [dbo].[SysRoleRight] ON 
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (1, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'0167D372-92AC-4981-A775-0AB0B3324824', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (2, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'2178FAA5-EE1A-4183-8F00-12E49DA24F37', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (3, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'29A2EC2B-6393-426F-BEFD-B24842D6803F', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (4, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'32383D2C-8A91-4A2F-90C6-442A052D2D46', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (5, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'3A3D2E9C-0E03-41A3-B0AD-0D290F6AB22B', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (6, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'451AFA16-3D7B-4C77-9777-69BEB64AEE47', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (7, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'6EEA82DA-B80C-417E-AD52-B61E2FD8A008', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (8, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'732AB120-7344-4F6B-9DDA-010067EA69F0', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (9, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'775ABE6A-300C-46C1-B3A4-7DD53A9F47BE', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (10, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'7F17E926-9B1A-4DCB-86C0-329113D53969', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (11, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'964086BC-B6B2-4DAC-BEDC-34B0F445315D', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (12, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'A3E85B22-8C6B-480D-9172-03CD31FB7346', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (13, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'B535DE6E-399D-44EF-B959-D37FE05992B5', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (14, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'C1CCFCA2-7F44-4898-8D0A-5CA327B0BDE5', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
INSERT [dbo].[SysRoleRight] ([RoleRightID], [RoleID], [ModuleID], [Creator], [CreateTime]) VALUES (15, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', N'D4119FC3-50DB-428F-8985-FA2615334374', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T15:34:22.9533333' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[SysRoleRight] OFF
GO
INSERT [dbo].[SysUserInfo] ([UserID], [Creator], [CreateTime], [UpdateBy], [UpdateTime], [Account], [UserName], [Password], [UserState], [RoleID], [LastLoginTime], [LastLoginIP]) VALUES (N'508C71A0-A076-45FD-8031-CD253BE82B9B', N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:56:42.5066667' AS DateTime2), N'508C71A0-A076-45FD-8031-CD253BE82B9B', CAST(N'2020-06-06T14:56:42.5066667' AS DateTime2), N'moontainer', N'admin', N'827CCB0EEA8A706C4C34A16891F84E7B', 1, N'1A06DB52-5C64-4F84-90CE-56710BA713D8', CAST(N'2020-06-06T15:39:32.0378847' AS DateTime2), NULL)
GO
