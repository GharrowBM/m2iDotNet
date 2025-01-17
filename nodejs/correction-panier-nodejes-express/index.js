const express = require("express")

const app = express()
const bodyParser = require("body-parser")

const fs = require("fs")
//stock nos produits dans un tableau js
let products = JSON.parse(fs.readFileSync("data/produits.json"))
const update = () => {
    fs.writeFileSync('data/produits.json', JSON.stringify(products))
}
//Dossier pour les ressources statiques (css, javascript)
app.use(express.static(__dirname+"/assets"))

app.use(express.urlencoded())
//Indiquer que le moteur de rendu est ejs
app.set("view engine","ejs")


//Route accueil
app.get('/', (req,res) => {
    //Renvoie le rendu généré par ejs à partir de la page  products.ejs
    let productsToDispaly = products
    //Dans le cadre de la recherche dans les params de la req, on aura un paramètre search non udenfined
    const search = req.query.search
    console.log(req)
    if(search != undefined) {
        productsToDispaly = products.filter(e => e.name.includes(search))
    }    
    res.render("pages/products", {
        products: productsToDispaly
    })
})

//Route afficher un produit
app.get('/product/:id', (req,res) => {
    const id = req.params.id
    if(products.length > id) {
        res.render('pages/product', {
            product : products[id],
            id: id
        })
    }
    else {
        res.render('pages/error')
    }
})

//Route pour supprimer un produit
app.get('/deleteproduct/:id', (req, res) => {
    const id = req.params.id
    if(products.length > id) {
        products.splice(id,1)
        update()
        res.redirect("/")
    }
})

//route pour le formulaire ajout du produit
app.get('/formProduct', (req,res) => {
    res.render('pages/form-product', {product:undefined, id: undefined})
})

//Route qui renvoie le formulaire, en récupérant le produit à modifier
app.get('/formProduct/:id', (req,res) => {
    //Récupération de l'id  du produit
    const id = req.params.id
    if(products.length > id) {
        //Récupération du produit
        const product = products[id]
        res.render('pages/form-product', {product:product, id: id})
    }else {
        res.render('pages/error')
    }
})

//Action pour valider le formulaire
app.post('/submitProduct', (req, res) => {
    //Soit on fait de l'ajout, soit c'est la modification

    const id = parseInt(req.body.id)
    //Un nouveau produit
    if(id== -1) {
        products = [...products, {name:req.body.name, price: req.body.price, category: req.body.category, description: req.body.description}]
    }
    else {
        //modification
        //On vérifie que le produit existe bien
        if(products.length > id) {
            products[id] = {name:req.body.name, price: req.body.price, category: req.body.category, description: req.body.description}
        }
    }
    update()
    res.redirect('/')
})

app.listen(80)



