<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class kategoriak extends Model
{
    use HasFactory;

    protected $table="kategoriak";
    public $timestamps=false;

    public function ingatlan() {
        return $this->hasMany(ingatlanok::class, 'ingatlanok', 'kategoria');
    }
}
