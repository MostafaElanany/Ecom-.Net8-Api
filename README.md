# Ecom-App-DotNet8-With-Angular

A full-featured e-commerce web application built with **ASP.NET Core 8 Web API** and **Angular 16**.  
The project implements a scalable architecture, secure authentication, Stripe payments, Redis caching, and modern frontend services.

---

## 🚀 Features

- 🛍️ Product browsing by categories
- 🧺 Shopping cart with **Redis** caching
- 🔐 Authentication with JWT (Register, Login, Forgot/Reset Password)
- 💳 Stripe payment integration
- 🔁 Server-side pagination for product lists
- 📦 Order and delivery management
- 🧰 Angular services for modular API communication
- 🛠️ Global exception handling middleware

---

## 🧪 Tech Stack

**Frontend:**
- Angular 16
- TypeScript
- SCSS

**Backend:**
- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- Redis (for basket caching)
- AutoMapper
- Stripe API

**Security:**
- ASP.NET Identity
- JWT Authentication

---

## 🛠️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js](https://nodejs.org/en) (for Angular)
- [Redis](https://redis.io/) (local or cloud instance)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Backend Setup

```bash
cd your-backend-folder
dotnet restore
dotnet ef database update
dotnet run
