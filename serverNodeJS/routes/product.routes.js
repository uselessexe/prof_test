const Router = require(`express`)
//const productController = require("../controller/product.controller")
const router = new Router()
const productController = require('../controller/product.controller')

router.post(`/product`,productController.CreateProd)
router.get(`/product`,productController.getProd)
router.get(`/product/:id`,productController.getProdID)
router.post(`/productsParams`,productController.getProdParam)
router.put(`/product`,productController.UpdProdID)

module.exports = router