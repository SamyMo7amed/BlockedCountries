# 🌍 Country Block & IP Geolocation API

![.NET Version](https://img.shields.io/badge/.NET-9.0-purple)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture%20%7C%20CQRS-blue)
![Storage](https://img.shields.io/badge/Storage-In--Memory%20(Thread--Safe)-green)

A high-performance, database-less **.NET 9 Web API** designed to manage blocked countries and validate incoming IP addresses using third-party geolocation services (ipapi.co). This project was developed as a technical test submission for **A Technologies**.

## 🚀 Live Demo & Repository
* **Live API (Swagger):** [countryTask.runasp.net](https://countryTask.runasp.net/swagger/index.html)
* **GitHub Repository:** [SamyMo7amed/BlockedCountries](https://github.com/SamyMo7amed/BlockedCountries)

---

## 🏗️ Architectural Highlights

To ensure scalability, maintainability, and enterprise-level code quality, this project implements the following patterns:

* **MediatR (CQRS Pattern):** Separates read and write operations into distinct queries and commands. This keeps controllers lean and ensures the Single Responsibility Principle.
* **Global Error Handling Middleware:** A centralized exception handling mechanism that captures all unhandled exceptions and returns a standardized, secure JSON response instead of leaking raw stack traces.
* **Standardized API Responses:** Every endpoint returns a consistent response envelope (`Succeeded`, `StatusCode`, `Message`, `Data`) for predictable frontend integration.
* **Thread-Safe In-Memory Storage:** Eliminates the need for a database by utilizing `ConcurrentDictionary` and `ConcurrentBag`, ensuring safe concurrent access across multiple requests.
* **Background Worker Service:** A hosted `BackgroundService` runs every 5 minutes to automatically sweep and remove expired "temporal blocks" from memory.

---

## 🛠️ Tech Stack

* **Framework:** .NET 9 Web API
* **Orchestration:** MediatR
* **Serialization:** `System.Text.Json` (Optimized for performance)
* **HTTP Client:** `IHttpClientFactory` for resilient third-party API integration
* **Documentation:** Swagger / OpenAPI

---

## 📌 Key Features

### 1. Country Management
* **Manual Block (`POST`):** Add specific country codes (e.g., "US", "EG") to the block list.
* **Temporal Block (`POST`):** Temporarily block a country for a designated duration (1-1440 minutes). Automatically unblocks upon expiration.
* **Unblock (`DELETE`):** Remove a country from the block list.
* **View Blocked (`GET`):** Retrieve a paginated list of blocked countries with optional search filtering by code or name.

### 2. IP Intelligence & Security
* **IP Geolocation Lookup (`GET`):** Fetch detailed information (Country Code, Country Name, ISP) for a specific IP or automatically detect the caller's IP.
* **Caller Block Check (`GET`):** Automatically extracts the user's IP via `HttpContext`, determines their country, and checks if they are blocked.

### 3. Monitoring & Logs
* **Blocked Attempts Log (`GET`):** Retrieves a paginated history of failed access attempts from blocked countries, logging the Timestamp, IP Address, Country Code, and UserAgent.

---

## ⚙️ Local Setup & Configuration

### 1. Clone the Repository
```bash
git clone [https://github.com/SamyMo7amed/BlockedCountries.git](https://github.com/SamyMo7amed/BlockedCountries.git)
cd BlockedCountries
