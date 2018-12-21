<Natural>
  <Dsl>
  @name test a person identity

  given person

  when person has identity
      (
      Person has name or
      Person has family
      ) and
      Must have a valid email
  then    
  otherwise
      Write Error ('identity could not be validated')
  end

  when Must have a valid email
    Email of person match "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
  then
  otherwise
    Write Error ('"{person.Email}" is an invalid email address')
  end

  when Person has name
          Name of person is not null and
          Name of person is not empty
  then        
  otherwise
      Write Error ('Name is required')

  end

  when Person has family
          Family of person is not null and
          Family of person is not empty
  then        
  otherwise
      Write Error ('Family is required')
  end

  /* writes an error message in the context of rules execution */
  when Write Error {msg}
  then
    /* $context is the execution context of logic documents look at wiki for $context */
    $context.WriteError(null,msg)
  end
  </Dsl>
</Natural>