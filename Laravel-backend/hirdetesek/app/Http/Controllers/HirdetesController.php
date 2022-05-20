<?php

namespace App\Http\Controllers;

use App\Models\ingatlanok;
use Illuminate\Http\Request;
use Exception;

class HirdetesController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        try {
            $ingatlanok = Ingatlanok::with('kategoria')->get();
            return response()->json($ingatlanok);
        } catch (Exception $e) {
            return response()->json([
                "message" => "Database Error!" .$e
            ], 400);
        }
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        //
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\ingatlanok  $ingatlanok
     * @return \Illuminate\Http\Response
     */
    public function show(ingatlanok $ingatlanok)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\ingatlanok  $ingatlanok
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, ingatlanok $ingatlanok)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\ingatlanok  $ingatlanok
     * @return \Illuminate\Http\Response
     */
    public function destroy(ingatlanok $ingatlanok)
    {
        //
    }
}
