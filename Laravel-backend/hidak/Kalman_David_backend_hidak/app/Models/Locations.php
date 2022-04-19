<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Locations extends Model
{
    use HasFactory;

    protected $table = "locations";
    public $timestamps = false;

    public function bridge() {
        return $this->hasMany(Bridges::class, 'bridges', 'location');
    }
}
