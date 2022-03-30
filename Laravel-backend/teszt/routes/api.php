<?php

use App\Http\Controllers\LeadasokController;
use App\Http\Controllers\TanuloController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

// Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
//     return $request->user();
// });

Route::get('/minden', [TanuloController::class, 'minden']);
// php artisan route:list
Route::get('/egytanuloleadasa/{id}', [TanuloController::class, 'egyTanuloLeadasa']);

Route::get('/egynap/{idopont}', [LeadasokController::class, 'egyNap']);
Route::get('/egynaptobbmennyiseg/{idopont}/{mennyiseg}/{irany}', [LeadasokController::class, 'egyNapTobbMennyiseg']);

//Route::apiResource('tanulok', TanuloController::class);
