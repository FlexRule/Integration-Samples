@name test a person identity

input person
output hasName, hasFamily

when Person has name
        Name of person is not null and
        Name of person is not empty
then 
        set hasName to true
end

when Person has family
        Family of person is not null and
        Family of person is not empty
then 
        set hasFamily to true
end
