# AspNetMvcCSP

CSP Nonce solution for ASP .NET Core MVC with Docker Compose. Nginx as load balancer between two server Docker containers.

## Usage

Download [Docker Desktop](https://www.docker.com/products/docker-desktop/) to be able to use Docker Compose.

```docker compose up```

This will fire up the nginx container + 2 instances of the application to simulate packages being server from multiple VM instances.

Webapp can be accessed at: http://localhost:8080/

If you take a look at the calls in DevTools -> Network tab, you can see X-Instance-Id in the Response Headers. It either can be server1
or server2. That marks which instance server the request. Also see that nonce differs on each request.