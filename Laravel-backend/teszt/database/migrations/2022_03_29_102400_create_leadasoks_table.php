<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('leadasok', function (Blueprint $table) {
            $table->integer('sorszam')->autoIncrement();
            $table->integer('tanulo');
            $table->date('idopont');
            $table->integer('mennyiseg');
            $table->foreign("tanulo")
                ->references('tazon')
                ->on('tanulok')
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
        Schema::dropIfExists('leadasok');
    }
};
