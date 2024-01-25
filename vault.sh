sleep 5 &&

curl -X POST 'http://vault:8200/v1/secret/data/workflow-secretstore' -H "Content-Type: application/json" -H "X-Vault-Token: admin" -d '{ "data": {"workflowdb":"Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres;Include Error Detail=true;"} }'
