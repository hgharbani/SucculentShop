
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/13/2019 18:59:03
-- Generated from EDMX file: C:\Users\h.gharbani\source\repos\SucculentShop\DataLayer\MyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyEshop_Db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Group_Product_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Group] DROP CONSTRAINT [FK_Product_Group_Product_Group];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Product_Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Group];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int  NOT NULL,
    [RoleTittle] nvarchar(50)  NULL,
    [RoleName] varchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [Password] varchar(200)  NOT NULL,
    [Email] nvarchar(500)  NOT NULL,
    [ActiveCode] varchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [RegisterDate] datetime  NOT NULL,
    [ImageUser] nvarchar(max)  NULL,
    [UserName] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'Product_Group'
CREATE TABLE [dbo].[Product_Group] (
    [GroupId] int IDENTITY(1,1) NOT NULL,
    [GroupTitle] nvarchar(400)  NOT NULL,
    [ParentId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [GroupId] in table 'Product_Group'
ALTER TABLE [dbo].[Product_Group]
ADD CONSTRAINT [PK_Product_Group]
    PRIMARY KEY CLUSTERED ([GroupId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [ParentId] in table 'Product_Group'
ALTER TABLE [dbo].[Product_Group]
ADD CONSTRAINT [FK_Product_Group_Product_Group]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[Product_Group]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Group_Product_Group'
CREATE INDEX [IX_FK_Product_Group_Product_Group]
ON [dbo].[Product_Group]
    ([ParentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------