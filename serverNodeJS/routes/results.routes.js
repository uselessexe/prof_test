const Router = require(`express`)
//const productController = require("../controller/product.controller")
const router = new Router()
const resultController = require('../controller/results.controller')

//router.post(`/product`,resultController.CreateRes)
router.get(`/resultsPP/:UserID/:testName`,resultController.getResultsPersonalPage)
//router.get(`/product/:id`,resultController.getResultID)

module.exports = router