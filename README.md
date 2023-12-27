## Build image:

1. git clone https://github.com/Shrigorevich/Venus.git
2. cd venus
3. docker build -f Venus/Dockerfile --tag=shrigorevich/venus-api:dev .
4. docker image push shrigorevich/venus-api:dev