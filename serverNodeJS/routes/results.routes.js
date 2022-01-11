const Router = require(`express`)
//const productController = require("../controller/product.controller")
const router = new Router()

const resultController = require('../controller/results.controller')

router.post(`/resultsPP`,resultController.getResultsPersonalPage)
router.get(`/loginPP/:UserID`,resultController.getLoginPersonalPage)
router.get(`/testsPP`,resultController.getLoginPersonalPage)


module.exports = router