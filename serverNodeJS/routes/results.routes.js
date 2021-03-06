const Router = require(`express`)
//const productController = require("../controller/product.controller")
const router = new Router()


const resultController = require('../controller/results.controller')

router.post(`/resultsPP`,resultController.getHistoryPersonalPage)
router.get(`/loginPP/:UserID`,resultController.getLoginPersonalPage)
router.get(`/testsPP`,resultController.getTestsPersonalPage)


const testController = require('../controller/tests.controller')

router.get(`/TestQuestAns/:TestID`,testController.getQuestionsAnswers)
router.get(`/TestResults/:TestID`,testController.getTests)
router.post(`/TestRecResults`,testController.RecResults)

module.exports = router