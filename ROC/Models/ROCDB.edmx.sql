
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2011 20:49:26
-- Generated from EDMX file: E:\Develop\SourceCode\ROCMVC\ROC\ROC\Models\ROCDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ROC];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NewsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsSet];
GO
IF OBJECT_ID(N'[dbo].[NewsCategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsCategorySet];
GO
IF OBJECT_ID(N'[dbo].[ProjectCategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectCategorySet];
GO
IF OBJECT_ID(N'[dbo].[ProjectsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectsSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectDetailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectDetailSet];
GO
IF OBJECT_ID(N'[dbo].[PictureStorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PictureStorySet];
GO
IF OBJECT_ID(N'[dbo].[PictureStoryCategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PictureStoryCategorySet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NewsSet'
CREATE TABLE [dbo].[NewsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ModifiedTime] datetime  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Source] nvarchar(max)  NOT NULL,
    [ContentTime] datetime  NOT NULL,
    [MainContent] nvarchar(max)  NOT NULL,
    [CategoryID] int  NOT NULL
);
GO

-- Creating table 'NewsCategorySet'
CREATE TABLE [dbo].[NewsCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectCategorySet'
CREATE TABLE [dbo].[ProjectCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectsSet'
CREATE TABLE [dbo].[ProjectsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectDetailSet'
CREATE TABLE [dbo].[ProjectDetailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [DetailContent] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PictureStorySet'
CREATE TABLE [dbo].[PictureStorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Source] nvarchar(max)  NOT NULL,
    [DetailContent] nvarchar(max)  NOT NULL,
    [CategoryID] int  NOT NULL
);
GO

-- Creating table 'PictureStoryCategorySet'
CREATE TABLE [dbo].[PictureStoryCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [PK_NewsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NewsCategorySet'
ALTER TABLE [dbo].[NewsCategorySet]
ADD CONSTRAINT [PK_NewsCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectCategorySet'
ALTER TABLE [dbo].[ProjectCategorySet]
ADD CONSTRAINT [PK_ProjectCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectsSet'
ALTER TABLE [dbo].[ProjectsSet]
ADD CONSTRAINT [PK_ProjectsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectDetailSet'
ALTER TABLE [dbo].[ProjectDetailSet]
ADD CONSTRAINT [PK_ProjectDetailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PictureStorySet'
ALTER TABLE [dbo].[PictureStorySet]
ADD CONSTRAINT [PK_PictureStorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PictureStoryCategorySet'
ALTER TABLE [dbo].[PictureStoryCategorySet]
ADD CONSTRAINT [PK_PictureStoryCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------