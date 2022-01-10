//const { Pool } = require("pg")
const Pool = require('pg').Pool
const pool = new Pool({
    user:"postgres",
    password:"fuck",
    host:"localhost",
    port:5432,
    database:"TestPrototype1"
    //database:"postgres"
})

module.exports = pool 