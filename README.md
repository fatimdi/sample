# TGWorkshop - Sample Project
Sample Project with .Net 8 using EF code first

## Getting Started

### Prerequisites

* .Net 8
* EF Code First
* Repository Pattern
* Docker

## Running the project 

You can run project on http, https or IIS 

Also run project on docker:

Go to server root path

```cmd
docker build -t <image-name> .
docker run --rm -p 80:80 -i -t image-name:latest /bin/bash
```
or if you use windows you can start with Container (dockefile) 
*dont forget add environment to docker - you should add your connection string as environment on docker*

## Authors

* **Fatemeh Maddahi** - *Sample Project* - [fatimdi](https://github.com/fatimdi)
