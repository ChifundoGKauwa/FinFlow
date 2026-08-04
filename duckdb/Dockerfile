FROM ubuntu:24.04

RUN apt-get update && \
    apt-get install -y wget ca-certificates && \
    wget https://github.com/duckdb/duckdb/releases/download/v1.5.5/duckdb_cli-linux-amd64.zip && \
    apt-get install -y unzip && \
    unzip duckdb_cli-linux-amd64.zip && \
    mv duckdb /usr/local/bin/duckdb && \
    chmod +x /usr/local/bin/duckdb

WORKDIR /app

CMD ["tail","-f","/dev/null"]