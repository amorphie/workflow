# Amoprhie Workflow Engine
State Machine and flow chart orchestration workflow service based on Zeebe

## Sample Flows 
### User Lifecyle

User life cyle includes states and transitions. Same of transitions are handled by Zeebe.


```mermaid

stateDiagram-v2
    start: user-start
    active: user-active
    amlap: user-aml-approval
    ap: user-approval
    de: "user-deactivated"
    sus: "user-suspended"


    start --> ap : user-register
    ap --> amlap : user-registration-approve
    amlap --> active : user-registration-aml-approve
    amlap --> de : user-registration-aml-reject
    active --> sus : user-suspend
    active --> de : "user-deactive
    de --> active : user-activate-fd
    sus --> active : user-activate-fs

```
#### Zeebe Flow
This flow handlig **user-register,user-reegistration-approve, user-registration-aml-approve** and **user-registration-aml-reject** transitions.

![user-register-flow](https://github.com/amorphie/workflow/blob/8eab7ed11bd88712937d4c1d053696d0936f6914/docs/images/user-register.png)

       

