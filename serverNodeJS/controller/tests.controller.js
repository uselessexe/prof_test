const db = require('../db')
class TestController{
    
    async getQuestionsAnswers(req,res){
        const id = req.params.TestID
        const checkData =await db.query(`SELECT * FROM \"Question\" q JOIN \"Answer\" a
        on (a.\"QuestionID\"=q.\"QuestionID\")
        WHERE \"TestID\" = $1
        ORDER BY a.\"QuestionID\",\"AnswerID\"`,[id])

        if (checkData.rowCount>0)
            res.json(checkData.rows)
        else
        {
            res.json()
        } 
    }
    
    async getTests(req,res){
        const id = req.params.TestID
        const checkData =await db.query(`SELECT * FROM \"Result\" WHERE \"TestID\" = $1`,[id])

        if (checkData.rowCount>0)
            res.json(checkData.rows)
        else
        {
            res.json()
        } 
    }
    async ShowResults(req,res){
        const {UserID,Date,TestID,Statistics} = req.body
        const newData =await db.query(`INSERT INTO \"ResultHistory\"
        (\"UserID\",\"Date\",\"TestID\",\"Statistics\"  RETURNING *)
        $" VALUES($1,$2,$3,$4)`,[UserID,Date,TestID,Statistics])

        if (checkData.rowCount>0)
            res.json(newData.rows[0])
        else
        {
            res.json()
        }
    }
}
module.exports = new TestController()