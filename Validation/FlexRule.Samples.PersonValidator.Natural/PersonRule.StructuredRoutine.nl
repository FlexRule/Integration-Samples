@name test a person identity

/* input variable from application */
given person

when person has identity
    (
    Person has name or
    Person has family
    ) and
    Email of person match "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
end

when Person has name
        Name of person is not null and
        Name of person is not empty
end
when Person has family
        Family of person is not null and
        Family of person is not empty
end