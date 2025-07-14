<div align="center">
  <h1>Modern E-Commerce Platform</h1>
  <p>A cloud-ready, modular, microservices-based e-commerce system built with ASP.NET Core, leveraging clean architecture, secure payment integration, and scalable communication.</p>
  
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="csharp" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="dotnet" />
  <img src="https://img.shields.io/badge/Microservices-00BFFF?style=for-the-badge&logo=microstrategy&logoColor=white" alt="microservices" />
  <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white" alt="jwt">
  <img src="https://img.shields.io/badge/Azure_Service_Bus-0078D4?style=for-the-badge&logo=microsoftazure&logoColor=white" alt="azure">
  <img src="https://img.shields.io/badge/Stripe-635BFF?style=for-the-badge&logo=stripe&logoColor=white" alt="stripe" />
  <img src="https://img.shields.io/badge/API%20Gateway-FF9900?style=for-the-badge&logo=amazonapi&logoColor=white" alt="api-gateway" />
  <img src="https://img.shields.io/badge/MVC%20Frontend-FF69B4?style=for-the-badge&logo=dotnet&logoColor=white" alt="mvc" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white" alt="Swagger" />
</div>

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Database Design](#database-design)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [API Documentation](#api-documentation)
- [Message Bus Integration](#message-bus-integration)
- [Payments](#payments)
- [Contributing](#contributing)

---

## Overview

This e-commerce platform is designed using a **Microservices Architecture**, allowing services to operate independently and scale efficiently. The system supports secure transactions via **Stripe**, uses **Azure Service Bus** for asynchronous messaging, and includes an **API Gateway** to route requests and manage authentication with **JWT tokens**.

---

## Features

- Modular and independent microservices
- Each microservice has its **own database**
- Secure **payment processing** with Stripe
- Real-time communication via **Azure Service Bus**
- Authentication and authorization via **JWT**
- Unified access point through an **API Gateway**
- Admin and customer interaction through **ASP.NET MVC frontend**
- Clean architecture with CQRS and MediatR
- Swagger UI for testing and documentation

---

## Architecture

- **Backend:** Multiple .NET Web APIs acting as microservices  
- **Frontend:** ASP.NET MVC application consuming APIs  
- **Communication:** JSON-based HTTP calls & Azure Service Bus  
- **Security:** JWT Token + API Gateway  
- **Database:** Each microservice owns its separate SQL Server database  
- **Payments:** Stripe integration for checkout  

---

## Database Design

Each microservice has its own isolated database schema.

![db1](./assets/db1.png)
![db2](./assets/db2.png)

---

## API Endpoints

Each service exposes a clear set of RESTful endpoints. Documentation is available via Swagger.

![endpoints](./assets/api1.png)
![endpoints](./assets/api2.png)

---

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Azure Account (or Azurite for local testing)](https://azure.microsoft.com/)
- [Stripe Account (for test keys)](https://stripe.com/docs/testing)

### Setup

1. Clone the repository

   ```bash
   git clone https://github.com/your-username/ecommerce-microservices.git
   cd ecommerce-microservices
