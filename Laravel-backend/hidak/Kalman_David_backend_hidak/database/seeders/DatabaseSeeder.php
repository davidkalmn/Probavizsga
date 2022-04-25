<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\File;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        // \App\Models\User::factory(10)->create();

        DB::statement('SET FOREIGN_KEY_CHECKS=0');
        \App\Models\Bridges::truncate();
        \App\Models\Locations::truncate();
        DB::statement('SET FOREIGN_KEY_CHECKS=1');

        $locations = [
            (object)['locationName' => 'Baja-Pörböly'],
            (object)['locationName' => 'Budapest'],
            (object)['locationName' => 'Budapest-Dunakeszi'],
            (object)['locationName' => 'Budapest-Szigetszentmiklós'],
            (object)['locationName' => 'Dunaföldvár-Solt'],
            (object)['locationName' => 'Dunaújváros-Dunavecse'],
            (object)['locationName' => 'Szekszárd-Dusnok'],
        ];
        foreach ($locations as $key => $value) {
            \App\Models\Locations::create([
              key($value) => $value->locationName  
            ]);
        }

        $json = File::get('database/data/bridges.json');
        $bridges = json_decode($json);
        foreach ($bridges as $key => $value) {
            \App\Models\Bridges::create([
                "id" => $value->_id,
                "bridgeName" => $value->bridgeName,
                "description" => $value->description,
                "isPublicRoad" => $value->isPublicRoad,
                "flowKm" => $value->flowKm,
                "routes" => $value->routes,
                "location" => $value->location,
                "deliveryDate" => $value->deliveryDate,
                "pictureUrl" => $value->pictureUrl,
            ]);
        }
    }
}
