sleep 5 &&

curl -X POST 'http://vault:8200/v1/secret/data/workflow-secretstore' -H "Content-Type: application/json" -H "X-Vault-Token: admin"  -d '{ 
    "data": {
        "workflowdb":"Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres;Include Error Detail=true;",
        "postgresql":"Host=localhost:5432;Database=users;Username=postgres;Password=postgres",
        "templateEngineUrl":"https://test-template-engine.burgan.com.tr/Template/Render",
        "templateEngine":"https://test-template-engine.burgan.com.tr",
        "messagingGatewayUrl":"https://test-messaginggateway.burgan.com.tr/api/v2/Messaging/sms/message",
        "hubUrl":"amorphie-workflow-hub.test-amorphie-workflow-hub",
        "redisEndPoints" : "localhost:6379",

        "Serilog:MinimumLevel:Default" : "Information",
        "Serilog:MinimumLevel:Override:Microsoft" : "Warning",
        "Serilog:MinimumLevel:Override:Microsoft.AspNetCore" : "Warning",
        "Serilog:MinimumLevel:Override:Microsoft.Hosting.Diagnostics" : "Warning",
        "Serilog:MinimumLevel:Override:Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware" : "Information",
        "Serilog:MinimumLevel:Override:System" : "Warning",
        "Serilog:MinimumLevel:Override:amorphie.workflow" : "Information",
        
        "Serilog:WriteTo:1:Name" : "Elasticsearch",
        "Serilog:WriteTo:1:Args:indexFormat" : "amorphie-wh-{0:yyyy.MM.dd}",
        "Serilog:WriteTo:1:Args:nodeUris" : "http://localhost:9200/",

        "Serilog:WriteTo:0:Name" : "File",
        "Serilog:WriteTo:0:Args:formatter" :"Serilog.Formatting.Compact.CompactJsonFormatter, Serilog.Formatting.Compact",
        "Serilog:WriteTo:0:Args:path" : "./logs/log-amorphie-exporter.json",
        "Serilog:WriteTo:0:Args:rollingInterval" : "Day" 
        }
    }'