const mongoose = require('mongoose')

const Schema = mongoose.Schema

const kategoriaSchema = new Schema({
    _id: Number,
    name: {
        type: Number,
        required: true,
        unique: true,
        maxlength: 30,
        rel: 'Hirdetes'
    }
})

module.exports = mongoose.model('Kategoria', kategoriaSchema, 'kategoria')