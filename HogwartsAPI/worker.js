var hogwartsLetterTemplateURL = "https://raw.githubusercontent.com/Miaad2004/Hogwarts-Management-System-in-C-Sharp-WPF/main/WebApp/Templates/Hogwarts_Letter/index.html";
var trainTicketTemplateURL = "https://raw.githubusercontent.com/Miaad2004/Hogwarts-Management-System-in-C-Sharp-WPF/main/WebApp/Templates/Hogwarts_Express_Ticket/index.html";

addEventListener('fetch', event => {
    event.respondWith(handleRequest(event.request))
  })
  
  async function handleRequest(request) {
    const url = new URL(request.url)
    const templateType = url.pathname.split('/')[1]
  
    if (request.method == 'GET')
    {
      // Base64 to Json
      let data
      try 
      {
        data = JSON.parse(atob(url.pathname.split('/')[2]))
      }
      catch (err) 
      {
        return new Response('Invalid JSON data', { status: 400 })
      }
      
      // Check if Input params are valid
      try 
      {
        validateInput(templateType, data);
      }
      catch (err) 
      {
        return new Response(err.message, { status: 400 })
      }
      
      // Respond
      if (templateType == 'hogwarts-letter') 
      {
        const template = await fetch(hogwartsLetterTemplateURL)
        const templateHTML = await template.text(template)
  
        // Modify the template
        const modifiedTemplate = templateHTML
        .replace('{{FirstName}}', data.FirstName)
        .replace('{{LastName}}', data.LastName)
        .replace('{{ActivationCode}}', data.ActivationCode)
        .replace('{{HeadmasterName}}', data.HeadmasterName)
  
        // Respond
        return new Response(modifiedTemplate, { headers: { 'Content-Type': 'text/html' } })
      } 
      else if (templateType == 'hogwarts-express-ticket') 
      {
        // Fetch the template
        const template = await fetch(trainTicketTemplateURL)
        const templateHTML = await template.text(template)
  
        // Modify the template
        const modifiedTemplate = templateHTML
        .replace('{{FirstName}}', data.FirstName)
        .replace('{{LastName}}', data.LastName)
        .replace('{{TrainNumber}}', data.TrainNumber)
        .replace('{{Departure}}', data.Departure)
        .replace('{{Date}}', data.Date)
        .replace('{{Time}}', data.Time)
        .replace('{{Seat}}', data.Seat)
        .replace('{{Compartment}}', data.Compartment)
  
        // Respond
        return new Response(modifiedTemplate, { headers: { 'Content-Type': 'text/html' } })
      } 
      else 
      {
        return new Response('Invalid template type', { status: 400 })
      }
    } 
    else
    {
      return new Response('Invalid method', { status: 400 })
    }
  }
  
function validateInput(templateType, data)
{
  const requiredFields =
  {
    'hogwarts-letter': ['FirstName', 'LastName', 'ActivationCode', 'HeadmasterName'],
    'hogwarts-express-ticket': ['FirstName', 'LastName', 'TrainNumber', 'Departure', 'Date', 'Time', 'Seat', 'Compartment']
  }

  const missingFields = requiredFields[templateType].filter(field => !data[field])

  if (missingFields.length > 0)
  {
    throw new Error(`Missing required fields: ${missingFields.join(', ')}`)
  }
}

  
  
  