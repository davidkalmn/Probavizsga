<?php

namespace App\Http\Controllers;

use App\Models\Leadasok;
use Illuminate\Http\Request;

class LeadasokController extends Controller
{
    public function egyNap($idopont) {
        return Leadasok::with('tanulo')
            ->where('idopont', '=', $idopont)
            ->get();
    }
    public function egyNapTobbMennyiseg($idopont,$mennyiseg,$irany) {
        return Leadasok::with('tanulo')
            ->where('idopont', '=', $idopont)
            ->where('mennyiseg', '>', $mennyiseg)
            ->orderBy('mennyiseg', $irany)
            ->get();

            // where() where() kapcsolata és
    }
}
