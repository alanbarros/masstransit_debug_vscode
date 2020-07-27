# Masstransit_RabbitMQ_Docker-Compose_DebugVsCode
Messtransit + RabbitMQ + Docker Compose + Debug on VsCode

### Run:

````bash
docker-compose -f "src\docker-compose.yml" up -d --build
````

This command will start three containers: rabbitmq server, a publisher (web api http://localhost:5100) and a listener (console app).

After that, execute this command in a terminal:

````
docker logs -f listener
````

This will abe you to see the messages that console app is listening

Now, run this command on a terminal with curl available, or use an rest client what you prefer.

````bash

curl --request POST --url http://localhost:5100/Messages --header 'content-type: application/json' --data '"Hello world!!"'

````
