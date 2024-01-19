curl -X POST 'http://vault:8200/v1/secret/data/workflow-secretstore' -H "Content-Type: application/json" -H "X-Vault-Token: admin"  -d '{ 
    "data": {
        "workflowdb":"Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres;Include Error Detail=true;",
        "postgresql":"Host=localhost:5432;Database=users;Username=postgres;Password=postgres",
        "templateEngineUrl":"https://test-template-engine.burgan.com.tr/Template/Render",
        "templateEngine":"https://test-template-engine.burgan.com.tr",
        "messagingGatewayUrl":"https://test-messaginggateway.burgan.com.tr/api/v2/Messaging/sms/message",
        "hubUrl":"amorphie-workflow-hub.test-amorphie-workflow-hub",
        "redisEndPoints" : "localhost:6379"
        }
    }'