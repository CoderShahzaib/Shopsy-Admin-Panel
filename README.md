Shopsy – E-Commerce Admin Panel (Demo)
Overview

Shopsy is a role-based e-commerce admin panel built using ASP.NET Core MVC and Web API.
It demonstrates real-world business workflows, including Admin and Seller roles, secure authentication, and order management. This is a personal demo project designed for learning and portfolio purposes.

Features
Role-Based Access

Admin

Full access to users, products, categories, orders, and reports

Manage Sellers

View total revenue and sales statistics

Seller

Manage own products

View and update own orders

Mark orders as delivered

Limited dashboard access

Authentication & Security

Cookie-based authentication for the admin panel

JWT authentication for Web API requests

Role-based authorization ([Admin] vs [Seller])

Secure handling of sensitive data

Order Management

Track all orders

Mark orders as delivered

View order details, customer info, and totals

Tech Stack

ASP.NET Core MVC (Admin Panel)

ASP.NET Core Web API

Entity Framework Core

JWT Authentication for APIs

Responsive UI with Razor Pages

Demo video: https://youtu.be/dSBhv4AToJI

Getting Started
Prerequisites

.NET 9 SDK

SQL Server or any compatible database

Visual Studio 2022 / VS Code

Installation

Clone the repository

git clone https://github.com/yourusername/Shopsy-Admin-Panel.git


Navigate to the project folder

cd Shopsy-Admin-Panel


Apply migrations

dotnet ef database update


Run the project

dotnet run

Usage

Login with demo Admin or Seller credentials

Explore dashboards and functionalities based on your role

Update order status (mark delivered)

Manage products, users, and categories (Admin only)

Notes

This is a demo project. All customer data shown in screenshots or video is fake/test data.

This project is not affiliated with any existing websites named Shopsy.
