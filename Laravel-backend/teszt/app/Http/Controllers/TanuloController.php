<?php

namespace App\Http\Controllers;

use App\Models\Tanulok;
use Exception;
use Illuminate\Http\Request;

class TanuloController extends Controller
{

    public function minden() {
        try {
            $minden = Tanulok::with('leadasok')->get();
        if ($minden->isEmpty()) {
            return response()->json(
                array("Message" => "No data!"),
                404
            );
        }
        else {
            return $minden;
        }
        } catch(Exception $e) {
            return response()->json(
                array("Message" => "Database error!"),
                400
            );
        }
    }

    public function egyTanuloLeadasa($id) {
        $tanulo = Tanulok::with('leadasok')
                    ->where('tanulok.tazon', '=', $id)
                    ->get();
        if ($tanulo->isEmpty()) {
            return response()->json(
                array("Message" => "No data!"),
                404
            );
        }
        else {
            return $tanulo;
        }
    }
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        return Tanulok::all();
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
