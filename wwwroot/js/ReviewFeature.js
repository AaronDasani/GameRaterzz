

$( document ).ready(function() {


    $(".ReviewSection .reviewContent").slideToggle("slow");
    $(".ListOfReviews .listOfComments").slideToggle();
    $(".ListOfReviews .CommentPostSection").slideToggle();

    
   $(".ReviewSection").on("click",".dropdown",function(e){
        e.preventDefault();
        // $(".ReviewSection").addClass("bg-light");
        $(".reviewContent").slideToggle("slow");

        
    })
    $(".ListOfReviews").on("click",".commentBtn",function(e){
        e.preventDefault();
        $(this).parent().parent().nextAll(".CommentPostSection").slideToggle("slow");

        
    })
    $(".ListOfReviews").on("click",".like",function(e){
        e.preventDefault();
        var variable=$(this);
        $.ajax({
            method:"GET",
            url:$(this).attr("href"),
            data:$(this).serialize(),
            success:function(response){
                variable.parent().parent().prevAll(".showInfo").children().first().children().children("span").html(response);

            }
        });
        return false;
            
    });
    // Adding Comments in Review
    $(".ListOfReviews .CommentForm").submit(function(e){
        e.preventDefault();
        var variable=$(this);
        $.ajax({
            method:"POST",
            url:$(this).attr("action"),
            data:$(this).serialize(),
            success:function(response){
                
                if (response!="Invalid") {
                    variable.parent().prevAll("div .showInfo").children().last().children().children().children("span").html(response["totalComment"])
                    
                    if(variable.parent().nextAll(".listOfComments").html()!=" ")
                    {
                        comment=` 
                            <div class="">
                                <div class="row">
                                    <div class="col-9">
                                        <small class="font-weight-bold badge badge-secondary">${response["userName"]}</small>
                                        
                                    </div>
                                </div>
                                
                                <p class="font-weight-light text-light ml-2 mt-2 mb-1">${response["comment"]["response"]}</p>
                                <hr>
                            </div>
                        `
                        variable.parent().nextAll(".listOfComments").append(comment)
                    }
                }
            }
        });
        $(this).parent().slideToggle("slow");
        
        
    })
        
    
    // View all comments in a particular Review
    $(".ListOfReviews").on("click",".viewComments",function(e){
        e.preventDefault();
        var variable=$(this);

        if(variable.parent().parent().parent().nextAll(".listOfComments").html()==" ")
        {
            $.ajax({
                method:"GET",
                url:$(this).attr("href"),
                data:$(this).serialize(),
                success:function(response){
                    var comment;
                    for (let index = 0; index < response.length; index++) {
                        
                        comment=` 
                            <div class="">
                                <div class="row">
                                    <div class="col-9">
                                        <small class="font-weight-bold badge badge-secondary">${response[index]["respondent"]["firstname"]} ${response[index]["respondent"]["lastname"]}</small>
                                        
                                    </div>
                                </div>
                                
                                <p class="font-weight-light ml-2 mt-2 mb-1 text-light">${response[index]["response"]}</p>
                                <hr>
                            </div>
                            
                        `
                        variable.parent().parent().parent().nextAll(".listOfComments").append(comment)
                    }
                }
            });
        }
        variable.parent().parent().parent().nextAll(".listOfComments").slideToggle("slow");
        
        return false;
            
    });
    

});