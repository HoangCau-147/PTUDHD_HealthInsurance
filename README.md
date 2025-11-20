<div align="center"> 
<h1>Course project</h1>

![website](https://img.shields.io/badge/-website-4CAF50)
![insurance](https://img.shields.io/badge/-health--insurance-FF9800)
![reactjs](https://img.shields.io/badge/-react-61DAFB)
![dotnet](https://img.shields.io/badge/-.NET-512BD4)
</div>

---
<p align="center">
 <img src="/Report/Logo.png" alt="Logo" height = "400"></a>
</p>

<h2 align="center">Health Insurance Management System</h2>

---

## 📖 Table of Contents
- [📝 Context](#-context)
- [📄 Introduction](#-introduction)
- [⿻ Layer](#-layer)
- [⚙️ Features](#-all-features)
- [📱 UI](#-ui)
- [💻 Technical](#-technical)
- [👥 Members](#-members)
---

## 📝 Context
In recent years, the demand for personal health insurance has significantly increased due to factors such as rising chronic diseases, population growth, and growing individual health awareness. 
Feedback from current customers indicates that our website for consulting and registering personal health insurance falls short, particularly in service experience, data management, and risk assessment.
- 82% of customers chose competitors due to better service experience from registration to post-purchase support.
- Over 40% of customers reported poor data handling on the website.
- Misjudgment in risk assessment recently led to a 10% cost loss.

To better serve existing customers and expand into competitive markets, we need to develop a website that effectively improves user experience, data management, and risk assessme

| Current Status | Feedback |
|:--:|:--:|
| ![image](Report/Picture1-1.png) | ![image](Report/Picture1-2.png) |
---

## 📄 Introduction
A Health Insurance Management System designed as a web application to streamline critical processes in the health insurance sector. Customers can review, explore, and register for insurance plans, while insurance agents can upload and manage insurance policies.

---

## ⿻ Layer
* The project applies the clean architecture principles to implement the code.

```
    └── 📁PTUDHD_HealthInsurance
    └── 📁Back-end
        └── 📁BaoHiem_WebAPI             => Main backend API project
            └── 📁App.Test                => Unit & integration tests
                └── 📁MockData           => Mock datasets for testing
                └── 📁System             => Test system logic
                    └── 📁Controller    => Controller tests
                    └── 📁Services      => Service tests
            └── 📁Config                  => Config files
            └── 📁Contracts               => Service interfaces / DTO definitions
                └── 📁ClaimContracts
                └── 📁CustomerContracts
                └── ...
            └── 📁Controller.Test         => Controller unit tests
            └── 📁Entity                  => Domain entities & models
                └── 📁Email
                └── 📁ErrorModels
                └── 📁Exceptions
                    └── 📁Customer
                    └── 📁Insurance
                    └── 📁Staff
                └── 📁Models
                    └── 📁Claim
                    └── 📁Customers
                    └── ...
            └── 📁Helper                  => Utility/helper classes
            └── 📁LoggerService           => Logging services
            └── 📁Repository              => Data access layer
                └── 📁Configuration
                └── 📁EntitiesRepository
                    └── 📁Claim
                    └── 📁Contracts
                    └── ...
            └── 📁Service.Contracts       => Interfaces for services
            └── 📁Services                => Service implementations
            └── 📁Shared                  => Shared DTOs, helpers, messages
                └── 📁EntityDtos
                    └── 📁Claim
                    └── 📁Contract
                    └── ...
                └── 📁Helper
                    └── 📁Hash
                    └── 📁Momo
                └── ...
            └── 📁WebAPI                  => API entry point & controllers
                └── 📁ContextFactory
                └── 📁Controllers
                    └── 📁Claim
                    └── 📁Contracts
                    └── ...
                    └── 📁Payments
                    └── 📁Staff
            ├── BaoHiem_WebAPI.sln
    └── 📁Front-end
        └── 📁public                     => Public assets for frontend
        └── 📁src
            └── 📁assets
            └── 📁components             => Reusable UI components
                └── 📁GlobalStyles
                └── 📁Layout
                    └── 📁components
                        └── 📁Footer
                        └── 📁Header
                        └── 📁Sidebar
                            └── 📁css
                                └── 📁aos
                    └── 📁DefaultLayout
                    └── 📁HeaderOnly
                    └── ...
            └── 📁helpers                 => Frontend utility functions
            └── 📁layouts                 => Layout templates
            └── 📁pages                   => Application pages
            └── 📁routes                  => Route definitions
            └── 📁services                => API/service calls
            └── 📁utils                   => Miscellaneous helpers
```

---

## ⚙️ Features

The system consists of three main subsystems: Customer and Insurance Company. Each subsystem interacts with the system by performing the following functions:

### 👨🏻‍👩🏻‍👦🏻‍👦🏻 Customer
* Register health insurance policies online
* Pay insurance fees online
* Request payments and treatment via email or mobile app
* Update and manage health insurance policies

#### 👨🏻‍💻 Insurance Company
* Review and approve applications using smart algorithms and data
* Determine insurance fees with accurate tools and calculation methods
* Process payment requests according to insurance rules and standards
* Update and upgrade health insurance policies
* Manage data, assess risk, control costs, and handle financial management

---

## 📱 UI

| Page1 | Page2 | Page3 |
|:--:|:--:|:--:|
| ![image](Report/Picture1.png) | ![image](Report/Picture2.png) | ![image](Report/Picture3.png) |
| ![image](Report/Picture4.png) | ![image](Report/Picture5.png) | ![image](Report/Picture6.png) |
| ![image](Report/Picture7.png) | ![image](Report/Picture8.png) | ![image](Report/Picture9.png) |
| ![image](Report/Picture10.png) | ![image](Report/Picture11.png) | ![image](Report/Picture12.png) |
| ![image](Report/Picture13.png) | ![image](Report/Picture14.png) | ![image](Report/Picture15.png) |
| ![image](Report/Picture16.png) | ![image](Report/Picture17.png) | ![image](Report/Picture18.png) |
| ![image](Report/Picture19.png) | ![image](Report/Picture20.png) | ![image](Report/Picture21.png) |
| ![image](Report/Picture22.png) | ![image](Report/Picture23.png) | ![image](Report/Picture24.png) |
| ![image](Report/Picture25.png) | ![image](Report/Picture26.png) | ![image](Report/Picture27.png) |
| ![image](Report/Picture28.png) | ![image](Report/Picture29.png) | ![image](Report/Picture30.png) |
| ![image](Report/Picture31.png) | ![image](Report/Picture32.png) | ![image](Report/Picture33.png) |
| ![image](Report/Picture34.png) |  | |

---

## 💻 Technical
* **Language**: SQL • C# • JavaScript
* **Framework**: ReactJS • Tailwind CSS
* **Database**: MS SQL Server
* **Backend**: ASP.NET Web API, Entity Framework Core code-first, Identity on ASP.NET Core, Dependency Injection (DI),

---

## 👥 Members
* NGUYỄN QUỐC ANH – 20120429 
* TÔ TRẦN SƠN BÁ – 20120431 
* HOÀNG  VĂN CẦU – 20120439 
* NGUYỄN ĐÌNH CƯỜNG – 20120446 
* NGUYỄN TRUNG HIẾU – 20120477 
