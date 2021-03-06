GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin', N'Admin', N'Admin', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'User', N'User', N'User', NULL)
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [Name], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'Ritesh', N'riteshoct7@gmail.com', N'RITESHOCT7@GMAIL.COM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEL3qncjs8KN0SbawO+itySYuYSZaFxK6uHjP7Jed7fuBdVyWM1ffkEjuBuITxTsPRQ==', N'JJBLBPENQIYUAG77R6DMLHGY6Q7D3JIR', N'0e84693f-6534-4591-aaac-df79efe65473', N'9974969561', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (2, N'User', N'user@gmail.com', N'USER@GMAIL.COM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEO5nK6j1S7xvQMlR20Z/vFAnGa9UvHg7NMYWJNjmzxdxLkz0fGD+BEw/yFlBZYuNMA==', N'62LERZTLEB7XCRKR2IHX4WXPKCYMR7UD', N'dbd1a448-b933-4d22-8a84-90457f264962', N'9974969561', 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (20, N'Pizza', N'Pizza')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (21, N'Beverages', N'Beverages')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (22, N'Desert', N'Desert')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (4, N'Veggie Paradise	', N'The awesome foursome! Golden corn, black olives, capsicum, red paprika	', CAST(499.00 AS Decimal(18, 2)), 20, N'/images/20210416T195153118.veggie_pizza.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (5, N'Cheese & Corn	', N'A delectable combination of sweet & juicy golden corn	', CAST(399.00 AS Decimal(18, 2)), 20, N'/images/20210416T195207629.cheese_n_corn.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (6, N'Non Veg Delight	', N'Chicken sausage, pepper barbecue chicken & peri-peri chicken in a fresh pan crust	', CAST(499.00 AS Decimal(18, 2)), 20, N'/images/20210416T195230286.noveg_delight.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (7, N'Non Veg Supreme', N'Loaded with a delicious creamy tomato pasta topping, pepper chicken, capsicum	', CAST(599.00 AS Decimal(18, 2)), 20, N'/images/20210416T195241627.nonveg_supreme.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (8, N'Choco Lava Cake	', N'Chocolate lovers delight! Indulgent, gooey molten lava inside chocolate cake	', CAST(99.00 AS Decimal(18, 2)), 22, N'/images/20210416T195253661.choco_lava.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (9, N'Butterscotch Cake	', N'Sweet temptation! Butterscotch flavored mousse	', CAST(99.00 AS Decimal(18, 2)), 22, N'/images/20210416T195309812.butter_scotch.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (10, N'Red Lava Cake', N'truly indulgent experience with sweet and rich red cake	', CAST(99.00 AS Decimal(18, 2)), 22, N'/images/20210416T195328898.red_cake.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (11, N'Pepsi	', N'Sparkling and Refreshing Beverage	', CAST(99.00 AS Decimal(18, 2)), 21, N'/images/20210416T195341710.pepsi.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (12, N'Mirinda	', N'Delicious Orange Flavoured beverage	', CAST(99.00 AS Decimal(18, 2)), 21, N'/images/20210416T195352555.mirinda.webp')
INSERT [dbo].[Products] ([Productid], [ProductName], [Description], [UnitPrice], [CategoryId], [ImageUrl]) VALUES (13, N' 7 Up	', N'Refreshing clear drink with lemon flavor', CAST(99.00 AS Decimal(18, 2)), 21, N'/images/20210416T195401488.7up.webp')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
