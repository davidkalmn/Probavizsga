<?php

namespace App\Http\Controllers;

use App\Models\Bridges;
use Illuminate\Http\Request;
use Exception;
use Illuminate\Support\Facades\Validator;

class BridgeController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index($field, $direction)
    {
        try {

            $bridges = Bridges::with('location')
                ->orderBy($field, $direction)
                ->get();
            return response()->json($bridges);

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
        

        try {
            $bridge = new Bridges;
            $bridge->bridgeName = $request->input('bridgeName');
            $bridge->description = $request->input('description');
            $bridge->isPublicRoad = $request->input('isPublicRoad');
            $bridge->flowKm = $request->input('flowKm');
            $bridge->routes = $request->input('routes');
            $bridge->location = $request->input('location');
            $bridge->deliveryDate = $request->input('deliveryDate');
            $bridge->pictureUrl = $request->input('pictureUrl');

            $bridge->save();
            return response()->json([
                'id' => $bridge->id
            ], 201);
        } catch (Exception $e) {
            return response()->json([
                "message" => $e
            ], 400);
        }
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Bridges  $bridges
     * @return \Illuminate\Http\Response
     */
    public function show(Bridges $bridges)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\Bridges  $bridges
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Bridges $bridges, $id)
    {
        try {
            if (Bridges::where('id', '=', $id)->exists()) {
                $ingatlan = Bridges::find($id);
                $ingatlan->bridgeName = $request->input('bridgeName');
                $ingatlan->description = $request->input('description');
                $ingatlan->isPublicRoad = $request->input('isPublicRoad');
                $ingatlan->flowKm = $request->input('flowKm');
                $ingatlan->routes = $request->input('routes');
                $ingatlan->location = $request->input('location');
                $ingatlan->deliveryDate = $request->input('deliveryDate');
                $ingatlan->pictureUrl = $request->input('pictureUrl');
                $ingatlan->update();
                return response()->json([
                   'message' => 'Ingatlan frissítve!'
                ],200);
            } else {
                return response()->json([
                    'message' => 'A híd '.$id.' nem létezik!'
                ], 404);
            }
        } catch (Exception $e) {
            return response()->json([
                "message" => $e
            ], 400);
        }
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Bridges  $bridges
     * @return \Illuminate\Http\Response
     */
    public function destroy(Bridges $bridges)
    {
        //
    }

    public function fieldValidator(Request $request)
    {
        $validator = Validator::make(
            $request->all(),
            [
                'kategoria' => 'required',
                'tehermentes' => 'required',
                'ar' => 'required'
            ]
        );
        if ($validator->fails()) {
            return false;
        }
        return true;
    }
}
