namespace RG.SecurityPrincipal {
    public sealed class Either<T1, T2> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2>(T1 value) => new(value);
        public static implicit operator Either<T1, T2>(T2 value) => new(value);
    }

    public sealed class Either<T1, T2, T3> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3>(T3 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4>(T4 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4, T5> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal
        where T5 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4, T5>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5>(T4 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5>(T5 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4, T5, T6> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal
        where T5 : ISecurityPrincipal
        where T6 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T4 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T5 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T6 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4, T5, T6, T7> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal
        where T5 : ISecurityPrincipal
        where T6 : ISecurityPrincipal
        where T7 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T4 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T5 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T6 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T7 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4, T5, T6, T7, T8> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal
        where T5 : ISecurityPrincipal
        where T6 : ISecurityPrincipal
        where T7 : ISecurityPrincipal
        where T8 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T4 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T5 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T6 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T7 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T8 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal
        where T5 : ISecurityPrincipal
        where T6 : ISecurityPrincipal
        where T7 : ISecurityPrincipal
        where T8 : ISecurityPrincipal
        where T9 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 value) => new(value);
    }

    public sealed class Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ISecurityPrincipal
        where T1 : ISecurityPrincipal
        where T2 : ISecurityPrincipal
        where T3 : ISecurityPrincipal
        where T4 : ISecurityPrincipal
        where T5 : ISecurityPrincipal
        where T6 : ISecurityPrincipal
        where T7 : ISecurityPrincipal
        where T8 : ISecurityPrincipal
        where T9 : ISecurityPrincipal
        where T10 : ISecurityPrincipal {
        public ISecurityPrincipal Value { get; }

        private Either(ISecurityPrincipal value) {
            Value = value;
        }

        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 value) => new(value);
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 value) => new(value);
    }
}
