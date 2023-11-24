@model GS.Models.Medico

@{
    ViewData["Title"] = "Add";
}

< h1 > Adicionar Beneficiários </ h1 >

< h2 > Beneficiários para adicionar</h2>

@if (TempData["msg"] != null)
{
    < div class= "alert alert-success" >
        @TempData["msg"]
    </ div >
}

< table class= "table" >
    < tr >
        < th > Nome </ th >
        < th ></ th >
    </ tr >
    @foreach(var item in ViewBag.beneficiarios)
    {
        < tr >
            < td > @item.Nome </ td >
            < td >
                < button onclick = "churros.value = @item.BeneficiarioId" type = "button" class= "btn btn-sm btn-outline-primary" data - bs - toggle = "modal" data - bs - target = "#exampleModal" >
                    Adicionar
                </ button >
            </ td >
        </ tr >
    }
</ table >
< !--Botão para voltar para a página de informações do Médico -->
<a asp-action="Detalhes" asp-route-id="@ViewBag.medico.MedicoId" class= "btn btn-primary" > Voltar </ a >

< !--Modal-- >
< div class= "modal fade" id = "exampleModal" tabindex = "-1" aria - labelledby = "exampleModalLabel" aria - hidden = "true" >
    < div class= "modal-dialog" >
        < div class= "modal-content" >
            < div class= "modal-header" >
                < h1 class= "modal-title fs-5" id = "exampleModalLabel" > Confirmação </ h1 >
                < button type = "button" class= "btn-close" data - bs - dismiss = "modal" aria - label = "Close" ></ button >
            </ div >
            < div class= "modal-body" >
                Deseja realmente adicionar o beneficiário ao médico?
            </div>
            <div class= "modal-footer" >
                < form asp - action = "Add" >
                    < input type = "hidden" name = "beneficiarioId" id = "churros" />
                    < input type = "hidden" name = "medicoId" value = "@ViewBag.medico.MedicoId" />
                    < button type = "button" class= "btn btn-secondary" data - bs - dismiss = "modal" > Não </ button >
                    < button type = "submit" class= "btn btn-primary" > Sim </ button >
                </ form >
            </ div >
        </ div >
    </ div >
</ div >
