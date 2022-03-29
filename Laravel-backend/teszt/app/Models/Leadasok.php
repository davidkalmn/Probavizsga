<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Leadasok extends Model
{
    use HasFactory;

    protected $table = 'leadasok';
    public $timestamp = false;

    //a fgv. neve az idegenkulcs
    public function tanulo() {
        return $this->belongsTo(Tanulok::class, 'tanulo', 'tazon');
    }
}
