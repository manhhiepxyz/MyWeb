CREATE TABLE [tbluser] (
  [id] int PRIMARY KEY,
  [name] nvarchar(255),
  [pass] nvarchar(255),
  [fullname] nvarchar(255),
  [email] nvarchar(255),
  [phone] nvarchar(255),
  [address] nvarchar(255),
  [role] int
)
GO

CREATE TABLE [tblrole] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255)
)
GO

CREATE TABLE [tblproduct] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255),
  [image] nvarchar(255),
  [price] decimal,
  [totalpage] int,
  [description] nvarchar(255),
  [author] nvarchar(255),
  [category] int
)
GO

CREATE TABLE [tblcategory] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255)
)
GO

CREATE TABLE [tblwishlist] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [user_id] int,
  [product_id] int
)
GO

CREATE TABLE [tblcart] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [user_id] int,
  [quantity] int
)
GO

CREATE TABLE [tblcartiteam] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [cart_id] int,
  [product_id] int,
  [quantity] int,
  [price] decimal
)
GO

CREATE TABLE [tblorder] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [user_id] int,
  [toltalprice] decimal,
  [payment_id] int,
  [shipment_id] int
)
GO

CREATE TABLE [tblorderiteam] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [order_id] int,
  [product_id] int,
  [quantity] int,
  [price] decimal
)
GO

CREATE TABLE [tblpayment] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [method] nvarchar(255),
  [amount] decimal,
  [user_id] int,
  [date] datetime
)
GO

CREATE TABLE [tblshipment] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [fullname] nvarchar(255),
  [phone] nvarchar(255),
  [address] nvarchar(255),
  [user_id] int,
  [status] nvarchar(255),
  [date] datetime
)
GO

ALTER TABLE [tblproduct] ADD FOREIGN KEY ([category]) REFERENCES [tblcategory] ([id])
GO

ALTER TABLE [tbluser] ADD FOREIGN KEY ([role]) REFERENCES [tblrole] ([id])
GO

ALTER TABLE [tblwishlist] ADD FOREIGN KEY ([user_id]) REFERENCES [tbluser] ([id])
GO

ALTER TABLE [tblwishlist] ADD FOREIGN KEY ([product_id]) REFERENCES [tblproduct] ([id])
GO

ALTER TABLE [tblcart] ADD FOREIGN KEY ([user_id]) REFERENCES [tbluser] ([id])
GO

ALTER TABLE [tblcartiteam] ADD FOREIGN KEY ([cart_id]) REFERENCES [tblcart] ([id])
GO

ALTER TABLE [tblcartiteam] ADD FOREIGN KEY ([product_id]) REFERENCES [tblproduct] ([id])
GO

ALTER TABLE [tblorderiteam] ADD FOREIGN KEY ([order_id]) REFERENCES [tblorder] ([id])
GO

ALTER TABLE [tblorderiteam] ADD FOREIGN KEY ([product_id]) REFERENCES [tblproduct] ([id])
GO

ALTER TABLE [tblshipment] ADD FOREIGN KEY ([user_id]) REFERENCES [tbluser] ([id])
GO

ALTER TABLE [tblpayment] ADD FOREIGN KEY ([user_id]) REFERENCES [tbluser] ([id])
GO

ALTER TABLE [tblorder] ADD FOREIGN KEY ([payment_id]) REFERENCES [tblpayment] ([id])
GO

ALTER TABLE [tblorder] ADD FOREIGN KEY ([shipment_id]) REFERENCES [tblshipment] ([id])
GO
