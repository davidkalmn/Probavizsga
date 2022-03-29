<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Tanulok extends Model
{
    use HasFactory;

    protected $table = 'tanulok';
    public $timestamp = false;

    public function leadasok() {
        return $this->hasMany(Leadasok::class, 'tanulo', 'tazon');
    }
}
