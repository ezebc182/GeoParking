
        function resetearControles()
        {
            for (i=0; i<document.forms[0].length; i++)
            {
                doc = document.forms[0].elements[i];
                switch (doc.type)
                {
                    case "text" :
                        doc.value = "";
                        break;

                    case "checkbox" :
                        doc.checked = false;
                        break;   

                    case "radio" :
                        doc.checked = false;
                        break;               

                    case "select-one" :
                        doc.options[doc.selectedIndex].selected = false;
                        break;                     

                    case "select-multiple" :
                        while (doc.selectedIndex != -1)
                        {
                            indx = doc.selectedIndex;
                            doc.options[indx].selected = false;
                        }
                        doc.selected = false;
                        break;                                   
                    default :
                        break;
                }
            }
        }
</script>