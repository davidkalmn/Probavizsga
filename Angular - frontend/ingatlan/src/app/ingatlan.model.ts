export class ingatlanModel {
    id:number = -1;
    kategoriaId:number = -1;
    kategoriaNev:string = "";
    leiras: string = "";
    hirdetesDatuma: string = new Date().toISOString().substring(0,10);
    tehermentes: boolean = false;
    kepUrl: string = "";
}