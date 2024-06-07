#Zeebe hazelcast exporter config -> application.yaml
hazelcast:
        className: io.zeebe.hazelcast.exporter.HazelcastExporter
        jarPath: exporters/zeebe-hazelcast-exporter.jar
        args:
                remoteAddress: hazelcast:5701 
                clusterName: "dev" 
                remoteConnectionTimeout: "PT30S" 
                format: "protobuf"
                name: "zeebe"
                capacity: 10000
                timeToLiveInSeconds: 0


#Zeebe with Hazelcast compose file

version: "3.9"
services:

  hazelcast:
    container_name: bbt-hazelcast
    image: hazelcast/hazelcast:5.4.0
    restart: always
    ports:
      - '5701:5701'
    volumes:
      - hazelcast:/data
    networks:
      - bbt-development

  hazelcastmg:
    container_name: bbt-hazelcastmng
    image: hazelcast/management-center:latest
    restart: always
    ports:
      - '5702:8080'
    volumes:
      - hazelcastmng:/data
    networks:
      - bbt-development

      
  zeebe:
    container_name: bbt_zeebe
    image: camunda/zeebe:8.4.4
    environment:
      - ZEEBE_LOG_LEVEL=debug
      - ZEEBE_HAZELCAST_REMOTE_ADDRESS=hazelcast:5701
    ports:
      - "26500:26500"
      - "9600:9600"
    volumes:
      - ./application.yaml:/usr/local/zeebe/config/application.yaml
      - ./zeebe-exporters/zeebe-hazelcast-exporter-1.4.0-jar-with-dependencies.jar:/usr/local/zeebe/exporters/zeebe-hazelcast-exporter.jar
    networks:
      - bbt-development
    depends_on:
      - hazelcast

  simple-monitor-postgres:
    container_name: zeebe-simple-monitor-postgres
    image: ghcr.io/camunda-community-hub/zeebe-simple-monitor:latest
    environment:
      - zeebe.client.broker.gateway-address=zeebe:26500
      - zeebe.client.worker.hazelcast.connection=hazelcast:5701
      - zeebe.client.worker.hazelcast.clusterName=dev
      - spring.datasource.url=jdbc:postgresql://postgres:5432/postgres
      - spring.datasource.username=postgres
      - spring.datasource.password=postgres
      - spring.datasource.driverClassName=org.postgresql.Driver
      - spring.jpa.properties.hibernate.dialect=org.hibernate.dialect.PostgreSQLDialect
    ports:
      - "8082:8082"
    depends_on:
      - zeebe
      - postgres
    networks:
      - bbt-development

  postgres:
    container_name: bbt-postgres
    image: postgres
    environment:
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: postgres
      PGDATA: /data/postgres
    volumes:
      - postgres:/data/postgres
    ports:
      - "5432:5432"
    restart: unless-stopped
    networks:
      - bbt-development

  vault:
   image: vault:1.13.3 
   container_name: vault 
   restart: on-failure:10 
   ports: 
     - "8200:8200" 
   environment: 
     VAULT_ADDR: 'https://0.0.0.0:8200' 
     VAULT_API_ADDR: 'https://0.0.0.0:8200' 
     VAULT_DEV_ROOT_TOKEN_ID: 'admin'
     VAULT_TOKEN: 'admin' 
   volumes:
     - ./file:/vault/file 
   cap_add: 
     - IPC_LOCK 
   healthcheck: 
      retries: 5 
   command: server -dev -dev-root-token-id="admin" 
   networks: 
      - bbt-development 
  vault-prepopulate: 
    image: alpine/curl 
    depends_on: 
    - vault 
    volumes: 
    - ./vault.sh:/usr/local/bin/prepopulate_vault.sh 
    command: ["sh", "-c", "/usr/local/bin/prepopulate_vault.sh"] 
    networks: 
    - bbt-development

networks:
  bbt-development:
    external: true

volumes:
  redis:
  hazelcast:
  hazelcastmng:
  postgres:
  redisinsight:
