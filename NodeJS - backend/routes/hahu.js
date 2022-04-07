var express = require('express');
const { json } = require('stream/consumers');
var router = express.Router();

const Hirdetes = require('../models/hirdetes')
const Kategoria = require('../models/kategoria')

router.post('/', function (req, res, next) {
    const _id = req.body._id
    const kategoria = req.body.kategoria
    const cim = req.body.cim
    const leiras = req.body.leiras
    const hirdetesDatuma = req.body.hirdetesDatuma
    const serulesMentes = req.body.serulesMentes
    const arFt = req.body.arFt
    const kepUrl = req.body.kepUrl

    const hirdetes = new Hirdetes({
        _id, kategoria, cim, leiras, hirdetesDatuma, serulesMentes, arFt, kepUrl
    })

    hirdetes
        .save(function (err) {
            if (err) {
                return res.status(400).json({
                    success: false,
                    message: err.message
                })
            }
            res.status(200).json({
                success: true
            })
        })
        .then(res.json({
            status: 'created'
        }))
        .catch((err) => {
            console.log(err)
        })


});

router.get('/:mezo', function(req,res,next) {
    const mezo = req.params.mezo
    Hirdetes
        .find()
        .populate('kategoria')
        .sort({[mezo]:1})
        .then(hirdetesek => {
            res.json(hirdetesek)
        })
        .catch(err => console.log(err))
})

router.delete('/:id', function(req,res,next) {
    const id = req.params.id

    Hirdetes
        .findById(id).then(doc => {
            if (doc === null) {
                return res.json({
                    'error' : `A hirdetés ${id} azonosítóval nem létezik!`
                })
            }
            Hirdetes
        .findByIdAndDelete(id)
        .then(res.json({
            'status': `A hirdetés ${id} azonosítóval törölve!`
        }))
        .catch(err => console.log(err))
        })

    
})

module.exports = router;
