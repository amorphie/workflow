
const { v4: uuid4 } = require("uuid");

function generateNewRecordId(input) {

    
    let uuid = uuid4();

    tc.setVar("newRecordId", uuid);
}

module.exports =[generateNewRecordId];