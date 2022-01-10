const db = require('../db')
class ResultsController{
    async getResultsPersonalPage(req,res){
        const id = req.params.UserID
        const testName = req.params.testName
        const results = await db.query(`SELECT \"Date\",\"Statistics\" FROM \"Users\" u JOIN \"ResultHistory\" rh on(u.\"UserID\"=rh.\"UserID\") JOIN \"Test\" t on (rh.\"TestID\"=t.\"TestId\") WHERE u.\"UserID\"=$1 AND \"TestName\"= \'$2\' ORDER BY \"ID\" DESC`,[id,testName])
        
        res.json(results.rows)
    }
    /*async getResultID(req,res){
        
    }*/
}
module.exports = new ResultsController()