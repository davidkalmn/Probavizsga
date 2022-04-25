<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateBridgesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('bridges', function (Blueprint $table) {
            $table->increments('id');
            $table->string('bridgeName', 100)->require()->unique();
            $table->string('description', 3000)->require();
            $table->boolean('isPublicRoad')->default(true);
            $table->double('flowKm')->require()->unique();
            $table->string('routes', 500);
            $table->integer('location')->require()->unsigned();
            $table->date('deliveryDate');
            $table->string('pictureUrl', 300);
            $table->foreign('location')
                ->references('id')
                ->on('locations')
                ->onDelete('cascade')
                ->onUpdate('restrict');
            //$table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('bridges');
    }
}
