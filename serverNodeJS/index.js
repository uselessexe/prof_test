const express = require('express')
const Router = require('./routes/results.routes')
//const Router = require('./routes/product.routes')


const PORT = process.env.PORT || 8080

const app = express()

app.use(express.json())
app.use('/api',Router)

//const jsonParser = express.json();

app.listen(PORT,()=>console.log(`server started on port ${PORT}`))
