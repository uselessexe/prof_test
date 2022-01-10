const db = require('../db')
class ProductController{
    async CreateProd(req,res){
        const{good,price,quantity}=req.body
        const newProd = await db.query(`INSERT INTO products (good,price,quantity) values ($1,$2,$3) RETURNING *`,[good,price,quantity])
        console.log(good,price,quantity)
        res.json(newProd.rows[0])
    }
    
    async getProd(req,res){
        const products = await db.query(`SELECT * FROM products`)
        res.json(products.rows)
    }
    async getProdID(req,res){
        const id = req.params.id
        const product = await db.query(`SELECT * FROM \"products\" WHERE id = $1`,[id])
        res.json(product.rows[0])
    }
    async getProdParam(req,res){
        const par = req.params.good
        const product = await db.query(`SELECT * FROM \"products\" WHERE good = $1`,[par])
        res.json(product.rows)
    }
    async UpdProdID(req,res){
        const{id,good,price,quantity}=req.body
        const updProd = await db.query(`UPDATE products SET good = $1,price = $2, quantity = $3 WHERE id =$4 RETURNING *`,[good,price,quantity,id])
        res.json(updProd.rows[0])
    }
}
module.exports = new ProductController()
