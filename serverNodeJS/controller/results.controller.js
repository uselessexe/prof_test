const db = require('../db')
class ResultsController{
    
    async getHistoryPersonalPage(req,res){
        const {UserId,TestName} = req.body
        const checkData =await db.query(`SELECT \"Date\",
        \"Statistics\" FROM \"Users\" u JOIN \"ResultHistory\"
         rh on(u.\"UserID\"=rh.\"UserID\") JOIN \"Test\" t on 
         (rh.\"TestID\"=t.\"TestId\") WHERE u.\"UserID\"=$1 AND
          \"TestName\"= $2 ORDER BY \"ID\" DESC`,[UserId,TestName])

        if (checkData.rowCount>0)
            res.json(checkData.rows)
        else
        {
            res.json()
        }
    }
    async getLoginPersonalPage(req,res){
        const id = req.params.UserID
        const checkData =await db.query(`SELECT \"Login\" FROM \"Users\" 
        WHERE \"UserID\"=$1`,[id])

        if (checkData.rowCount>0)
            res.json(checkData.rows[0])
        else
        {
            res.json()
        }
    }
    async getTestsPersonalPage(req,res){

        const checkData =await db.query(`SELECT \"TestName\"FROM \"Test\"`)

        if (checkData.rowCount>0)
            res.json(checkData.rows)
        else
        {
            res.json()
        }
    }
}
module.exports = new ResultsController()