<?php

namespace App\Http\Controllers;

use App\Models\Tanulok;
use Illuminate\Http\Request;

class TanuloController extends Controller
{

    public function minden() {
        return Tanulok::with('leadasok')->get();
    }
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        //
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
     * @param  \App\Models\Tanulok  $tanulok
     * @return \Illuminate\Http\Response
     */
    public function show(Tanulok $tanulok)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\Tanulok  $tanulok
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Tanulok $tanulok)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Tanulok  $tanulok
     * @return \Illuminate\Http\Response
     */
    public function destroy(Tanulok $tanulok)
    {
        //
    }
}
